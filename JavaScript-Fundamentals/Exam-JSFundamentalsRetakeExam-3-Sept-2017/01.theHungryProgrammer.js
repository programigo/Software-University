function getMeals(portions, commands) {
    let counter = 0;
    for (let command of commands) {
        command = command.split(/\s+/);

        if (command.length === 1) {
            let meal;

            switch (command[0]) {
                case 'Serve':
                    meal = portions.pop();
                    console.log(`${meal} served!`);
                    break;

                case 'Eat':
                    if (portions.length > 0) {
                        meal = portions.shift();
                        console.log(`${meal} eaten`);
                        counter++;
                        break;
                    }


                case 'End':
                    if (portions.length > 0) {
                        console.log(`Meals left: ${portions.join(', ')}`);
                    } else {
                        console.log('The food is gone');
                    }

                    console.log(`Meals eaten: ${counter}`);
            }
        } else if (command.length === 2) {
            switch (command[0]) {
                case 'Add':
                    let meal = command[1];
                    portions.unshift(meal);
                    break;
            }
        } else if (command.length === 3) {
            switch (command[0]) {
                case 'Consume':
                    let startIndex = Number(command[1]);
                    let endIndex = Number(command[2]);

                    if (startIndex != undefined && endIndex != undefined) {
                    if (endIndex - startIndex < portions.length) {

                            let eatenMeals = portions.splice(startIndex, endIndex - startIndex + 1);
                            counter += eatenMeals.length;
                            console.log(`Burp!`);
                        }
                        break;
                    }

                case 'Shift':
                    let firstIndex = Number(command[1]);
                    let secondIndex = Number(command[2]);

                    let firstMeal = portions[firstIndex];
                    let secondMeal = portions[secondIndex];

                    portions[firstIndex] = secondMeal;
                    portions[secondIndex] = firstMeal;
            }
        }
    }
}

getMeals(['soup', 'spaghetti', 'eggs'],
    ['Consume 0 2',
        'Eat',
        'Eat',
        'Shift 0 1',
        'End',
        'Eat']
);