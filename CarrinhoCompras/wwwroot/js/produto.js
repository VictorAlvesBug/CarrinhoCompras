
import { createHttpRequest } from './httpRequestFactory.js';

const httpRequest = createHttpRequest();

carregarCarrinho();

function popularCarrinho(carrinho) {
	const divLista = document.querySelector('.carrinho-partial');

	if (carrinho.listaProdutos.length === 0) {
		divLista.innerHTML = '<div class="nenhum-produto">Nenhum produto encontrado</div>';
		return;
	}

	let listaDivProdutos = carrinho.listaProdutos.reduce((acc, produto) => {
		const podeRemover = produto.qtdeSelecionada > 0;
		const podeAdicionar = produto.qtdeSelecionada < produto.qtdeEmEstoque;

		const classeHabilitarRemocao = podeRemover ? "btn-ativado" : "";
		const classeHabilitarAdicao = podeAdicionar ? "btn-ativado" : "";

		return `
            ${acc}
            <div class="item-produto-container"
				data-codigo-produto="${produto.codigo}">
                <div class="item-produto-content">
                    <div class="item-produto-info-container">
                        <div class="item-produto-nome">${produto.nome}</div>
                        <div class="item-produto-preco">
							${produto.precoUnitarioFormatado}
						</div>
                    </div>
                    <div class="item-produto-selecao-container">
						<div class="item-produto-subtotal">
							${produto.precoSubTotalFormatado}
						</div>
                        <div class="item-produto-selecao-remover js-btn-remover-produto  ${classeHabilitarRemocao}">
							-
						</div>
                        <div class="item-produto-selecao-qtde">
							${produto.qtdeSelecionada}
						</div>
                        <div class="item-produto-selecao-adicionar js-btn-adicionar-produto ${classeHabilitarAdicao}">
							+
						</div>
                    </div>
                </div>
            </div>
            `;
	}, '');

	const podeFinalizarCompra = carrinho.listaProdutos.some(produto => produto.qtdeSelecionada > 0);

	const classeHabilitarCompra = podeFinalizarCompra ? "btn-ativado" : "";

	let divPrecoTotalSemDesconto = '';

	if (carrinho.precoTotalSemDesconto !== carrinho.precoTotalComDesconto) {
		divPrecoTotalSemDesconto =
			`
				<div class="carrinho-preco-total-sem-desconto">
					${carrinho.precoTotalSemDescontoFormatado}
				</div>
			`;
	}

	listaDivProdutos += `
            <div class="item-produto-container">
                <div class="item-produto-content">
                    <div class="item-produto-info-container">
                        <div class="item-produto-total">
							Total
						</div>
                    </div>
                    <div class="item-produto-selecao-container">
						${divPrecoTotalSemDesconto}
						<div class="carrinho-preco-total-com-desconto">
							${carrinho.precoTotalComDescontoFormatado}
						</div>
                        <div class="btn-finalizar-compra js-btn-finalizar-compra ${classeHabilitarCompra}">
							Comprar
						</div>
                    </div>
                </div>
            </div>
		`;

	divLista.innerHTML = `
        <div class="grid-produtos">
            ${listaDivProdutos}
        </div>
        `;
}

function popularCalculoDescontosCarrinho(carrinho) {
	const divCalculoDescontos = document.querySelector('.calculo-descontos-carrinho');

	if (carrinho.listaInfoDescontosAplicados.length === 0) {
		divCalculoDescontos.innerHTML = '<div class="nenhum-desconto">Nenhum desconto encontrado</div>';
		return;
	}

	let listaDivDescontos = carrinho.listaInfoDescontosAplicados.reduce((acc, desconto) => {
		return `
				${acc}
				<div class="item-desconto-container">
					<div class="motivo-desconto">
						${desconto.motivoDesconto}
					</div>
					<div class="precos-container">
						<span>${desconto.precoAntesFormatado}</span>
						-
						<span>${desconto.valorDescontoFormatado}</span>
						=
						<span>${desconto.precoDepoisFormatado}</span>
					</div>
				</div>
			`;
	}, '')

	divCalculoDescontos.innerHTML = `
			<div class="grid-descontos">
				${listaDivDescontos}
			</div>
		`;
}

function carregarCarrinho() {
	httpRequest.get({
		url: '/Home/RetornarCarrinho',
		success: (carrinho) => {
			if (carrinho) {
				popularCarrinho(carrinho);
				popularCalculoDescontosCarrinho(carrinho);
			carregarEventListeners();
			}
			else {
				console.error('Ocorreu um erro ao retornar carrinho');
			}
		},
		error: (err) => {
			console.error('Ocorreu um erro:', err);
		}
	});
}

function carregarEventListenerQtdeItens(classe, url) {
	const listaBtnRemoverProduto = document.querySelectorAll(`.${classe}.btn-ativado`);

	listaBtnRemoverProduto.forEach(btnRemoverProduto => {
		btnRemoverProduto.addEventListener('click', ({ target }) => {
			const divItemProdutoContainer = target.closest('.item-produto-container');

			const codigoProduto = parseInt(divItemProdutoContainer.getAttribute('data-codigo-produto'));

			httpRequest.post({
				url: url,
				data: {
					codigo: codigoProduto
				},
				success: (retorno) => {
					if (retorno.sucesso) {
						carregarCarrinho();
					}
					else {
						console.error('Ocorreu um erro ao atualizar:', retorno);
					}
				},
				error: (err) => {
					console.error('Ocorreu um erro:', err);
				}
			});
		});
	});
}

function carregarEventListenerFinalizarCompra() {
	const btnFinalizarCompra = document.querySelector('.js-btn-finalizar-compra.btn-ativado');

	if (!btnFinalizarCompra) {
		return;
	}

	btnFinalizarCompra.addEventListener('click', () => {
		httpRequest.post({
			url: '/Home/FinalizarCompra',
			success: (retorno) => {
				if (retorno.sucesso) {
					alert('Compra finalizada com sucesso');
					carregarCarrinho();
				}
				else {
					console.error('Ocorreu um erro ao finalizada a compra:', retorno);
				}
			},
			error: (err) => {
				console.error('Ocorreu um erro:', err);
			}
		});
	});
}

function carregarEventListeners() {
	carregarEventListenerQtdeItens('js-btn-adicionar-produto', '/Home/AdicionarProduto');
	carregarEventListenerQtdeItens('js-btn-remover-produto', '/Home/RemoverProduto');
	carregarEventListenerFinalizarCompra();
}