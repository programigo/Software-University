(function processString() {
   return function modifyStr(commandsArr) {
        let stringToModify = '';
        for (let commandArgs of commandsArr) {
            let commandElements = commandArgs.split(' ');
            let currentCommand = commandElements[0];
            switch (currentCommand){
                case 'append':
                    let appender = commandElements[1];
                    stringToModify += appender;
                    break;

                case 'removeStart':
                    let numberOfLeadChars = Number(commandElements[1]);
                    stringToModify = stringToModify.slice(numberOfLeadChars);
                    break;

                case 'removeEnd':
                    let numberOfEndChars = Number(commandElements[1]);
                    stringToModify = stringToModify.slice(0, stringToModify.length - numberOfEndChars);
                    break;

                case 'print':
                    console.log(stringToModify);
            }
        }
    }
}
)();

