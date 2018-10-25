debugger;
TrelloPowerUp.initialize({
    //BOARDS  
    'board-buttons': function (t, options) {
        return [{
            text: 'Modal',

            callback: function (t) {
                return t.lists('all')
                    .then(function (lists) {
                        //console.log(JSON.stringify(lists, null, 2));
                        let oDados = JSON.stringify(lists, null, 2);
                        //for (let i = 0; i < oDados.length; i++) {
                        //	section.push(oDados[i]);
                        //}
                        localStorage.setItem('listas', oDados);
                        t.modal({
                            // the url to load for the iframe
                            url: '/Home/Listas',
                            // optional arguments to be passed to the iframe as query parameters
                            // access later with t.arg('text')
                            args: { text: 'TesteModal' },
                            // optional color for header chrome
                            accentColor: '#0079BF',
                            // initial height for iframe
                            height: 1000, // not used if fullscreen is true
                            // whether the modal should stretch to take up the whole screen
                            fullscreen: false,
                            // optional title for header chrome
                            title: 'Atividades Board',
                            // optional action buttons for header chrome
                            // max 3, up to 1 on right side
                            actions: [{
                                icon: 'https://cdn.glitch.com/7fe26656-897b-4249-97d8-02357291b32b%2Ficon.svg.png?1536458755205',
                                url: 'https://google.com',
                                alt: 'Left',
                                position: 'left'
                            }],
                        })
                    });
            }
        }
        ];
    }
}
);