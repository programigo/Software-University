let manager = function () {

    let recipes = {
        apple: {carbohydrate: 1, flavour: 2},
        coke: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        omelet: {protein: 5, fat: 1, flavour: 1},
        cheverme: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}
    };

    let cookRobot = {
        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    };

     return function operate(input) {

        let commandArgs = input.split(' ');

        switch (commandArgs[0]) {
            case 'restock':
                restockQuantity(commandArgs[1], commandArgs[2]);
                return 'Success';
            case 'prepare':
                let product = commandArgs[1];
                let quantity = Number(commandArgs[2]);

                let carbNeeded = recipes[product].carbohydrate * quantity;
                let flavourNeeded = recipes[product].flavour * quantity;
                let fatNeeded = recipes[product].fat * quantity;
                let proteinNeeded = recipes[product].protein * quantity;

                switch (commandArgs[1]) {
                    case 'apple':
                    case 'coke':
                        if (cookRobot.carbohydrate < carbNeeded) {
                            return 'Error: not enough carbohydrate in stock';
                        } else if (cookRobot.flavour < flavourNeeded){

                            return 'Error: not enough flavour in stock';
                        } else {
                            cookRobot.carbohydrate -= carbNeeded;
                            cookRobot.flavour -= flavourNeeded;
                            return 'Success';
                        }

                    case 'burger':
                        if (cookRobot.carbohydrate < carbNeeded) {
                            return 'Error: not enough carbohydrate in stock';
                        } else if (cookRobot.fat < fatNeeded) {
                            return 'Error: not enough fat in stock';
                        } else if (cookRobot.flavour < flavourNeeded) {
                            return 'Error: not enough flavour in stock';
                        } else {
                            cookRobot.carbohydrate -= carbNeeded;
                            cookRobot.fat -= fatNeeded;
                            cookRobot.flavour -= flavourNeeded;
                            return 'Success';
                        }

                    case 'omelet':
                        if (cookRobot.protein < proteinNeeded) {
                            return 'Error: not enough protein in stock';
                        } else if (cookRobot.fat < fatNeeded) {
                            return 'Error: not enough fat in stock';
                        } else if (cookRobot.flavour < flavourNeeded) {
                            return 'Error: not enough flavour in stock';
                        }else {
                            cookRobot.protein -= proteinNeeded;
                            cookRobot.fat -= fatNeeded;
                            cookRobot.flavour -= flavourNeeded;
                            return 'Success';
                        }

                    case 'cheverme':
                        if (cookRobot.protein < proteinNeeded) {
                            return 'Error: not enough protein in stock';
                        } else if (cookRobot.carbohydrate < carbNeeded) {
                            return 'Error: not enough carbohydrate in stock';
                        } else if (cookRobot.fat < fatNeeded) {
                            return 'Error: not enough fat in stock';
                        } else if (cookRobot.flavour < flavourNeeded) {
                            return 'Error: not enough flavour in stock';
                        }else {
                            cookRobot.protein -= proteinNeeded;
                            cookRobot.carbohydrate -= carbNeeded;
                            cookRobot.fat -= fatNeeded;
                            cookRobot.flavour -= flavourNeeded;
                            return 'Success';
                        }
                }
                break;
            case 'report':
                return `protein=${cookRobot.protein} carbohydrate=${cookRobot.carbohydrate} fat=${cookRobot.fat} flavour=${cookRobot.flavour}`;
        }

        function restockQuantity(microElement, quantity) {
            cookRobot[microElement] += Number(quantity);
        }
    };
};

let calling = manager();

calling('restock flavour 50');
calling('prepare coke 4');

