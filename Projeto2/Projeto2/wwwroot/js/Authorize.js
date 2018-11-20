let tokenG = '71a8982f578f5d2b5ff8aa10dea6d6d2';
let url = 'https://trello.com/1/authorize?expiration=1day&name=PowerUpTopZera&scope=read&response_type=token&key=';
let callback = '&return_url=' + window.location.href.split("Authorize")[0] + 'Authsuccess';
let urlFinal = url + tokenG + callback;
var Promise = TrelloPowerUp.Promise;
var t = TrelloPowerUp.iframe();

var apiKey = t.arg('apiKey');
var tokenLooksValid = function (token) {
	// If this returns false, the Promise won't resolve.

	var teste = /^[0-9a-f]{64}$/.test(token);
	return teste
}

document.getElementById('auth-btn').addEventListener('click', function () {
	console.log("entriu");
	t.authorize(urlFinal, { height: 680, width: 580, validToken: tokenLooksValid })
		.then(function (token) {
			// store the token in Trello private Power-Up storage

			return t.set('member', 'private', 'token', token)
		})
		.then(function () {
			// now that we have the token we needed lets go on to letting
			// the user do whatever they need to do.
			return t.closePopup();
		});
});