function parseDocument(input) {
    let pattern = /.*\s*<svg>\s*<cat>\s*<text>.*?\[(.*?)\]<\/text>\s*<\/cat>\s*<cat>(.*?)<\/cat><\/svg>.*\s*/gmi;
    let matcher = pattern.exec(input);

    let totalRatings = 0;
    let totalVotesCount = 0;

    if (matcher != null) {
        let ratings = matcher[2];
        let ratingsPattern = /<g>(<val>([1-9]|10)<\/val>)(0|[1-9][0-9]{0,5}|1000000)<\/g>/gmi;
        let ratingsMatcher;

        while (ratingsMatcher = ratingsPattern.exec(ratings)) {
            let value = Number(ratingsMatcher[2]);
            let votes = Number(ratingsMatcher[3]);

            totalRatings += value * votes;
            totalVotesCount += votes;
        }

        console.log(`${matcher[1]}: ${Math.round((totalRatings / totalVotesCount) * 100) / 100}`);

    } else {
        if (!input.includes('<svg>') || !input.includes('</svg>')) {
            console.log('No survey found');
        } else {
            console.log('Invalid format');
        }
    }
}

parseDocument('<svg><cat><text>Which is your favourite meal from our selection?</text></cat><cat><g><val>Fish</val>15</g><g><val>Prawns</val>31</g><g><val>Crab Langoon</val>12</g><g><val>Calamari</val>17</g></cat></svg>')
