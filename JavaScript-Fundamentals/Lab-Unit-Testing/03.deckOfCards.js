function printDeckOfCards(cards) {
    function makeCard(face, suit) {
        let validCards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let validSuits = {
            'S': "\u2660",
            'H': "\u2665",
            'D': "\u2666",
            'C': "\u2663"
        };

       if (validCards.indexOf(face) < 0 || !validSuits.hasOwnProperty(suit)) {
           throw new Error('Invalid input data!');
       }

        return {
            face,
            suit,

            toString: function () {
                return face + validSuits[suit];
            }
        };
    }

    for (let i = 0; i < cards.length; i++) {

        let face = cards[i].substring(0, cards[i].length - 1);
        let suit = cards[i][cards[i].length - 1];
        try {
            cards[i] = makeCard(face, suit);
        } catch (err) {
            console.log(`Invalid card: ${cards[i]}`);
            return;
        }

    }

    console.log(cards.join(' '));
}