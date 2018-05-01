function manipulateArray(arr) {
    let commandExecutor = (function () {
        let finalArr = [];

        function add(text) {
            finalArr.push(text);
        }

        function remove(text) {
            finalArr = finalArr.filter(word => word !== text);
        }

        function print() {
            console.log(finalArr.join(','));
        }

        return {add, remove, print};
    })();

    for (let i = 0; i < arr.length; i++) {
        let currentPair = arr[i].split(' ');
        let command = currentPair[0];
        let text = currentPair[1];

        commandExecutor[command](text);
    }
}

manipulateArray(['add hello', 'add again', 'remove hello', 'add again', 'print']);