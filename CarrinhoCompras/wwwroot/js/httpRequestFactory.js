
function createHttpRequest() {
	const get = (config) => {
		const xmlHttp = new XMLHttpRequest();

		xmlHttp.onreadystatechange = function () {
			if (xmlHttp.readyState === 4) {
				if (xmlHttp.status === 200) {
					config.success(JSON.parse(xmlHttp.response));
				}
				else {
					config.error(xmlHttp);
				}
			}
		}

		xmlHttp.open("GET", config.url, true);
		xmlHttp.send(null);
	}

	const post = (config) => {
		const xmlHttp = new XMLHttpRequest();

		xmlHttp.onreadystatechange = function () {
			if (xmlHttp.readyState === 4) {
				if (xmlHttp.status >= 200 && xmlHttp.status < 400) {
					config.success(JSON.parse(xmlHttp.response));
				}
				else {
					config.error(xmlHttp);
				}
			}
		}

		xmlHttp.open("POST", config.url, true);
		xmlHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

		const dataSerialized = new URLSearchParams(config.data).toString()
		xmlHttp.send(dataSerialized);
	}

	return {
		get,
		post
	};
}

export { createHttpRequest };

