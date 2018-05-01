(function modifyStr() {
    String.prototype.ensureStart = function (str) {
        let finalStr = '';
        if (!this.startsWith(str)) {
            finalStr = str + this.valueOf();
        } else {
            finalStr = this.valueOf();
        }

        return finalStr;
    };

    String.prototype.ensureEnd = function (str) {
        let finalStr = '';
        if (!this.endsWith(str)) {
            finalStr = this.valueOf() + str;
        } else {
            finalStr = this.valueOf();
        }

        return finalStr;
    };

    String.prototype.isEmpty = function () {
        return this.valueOf().length === 0;
    };

    String.prototype.truncate = function (n) {
        let finalStr = '';

        if (n < 4) {
            finalStr = '.'.repeat(n);
        }else if (this.valueOf().length <= n) {
            finalStr = this.valueOf();
        } else {
            let lastIndex = this.valueOf().substr(0, n - 2).lastIndexOf(" ");
            if(lastIndex != -1){
                finalStr =  this.valueOf().substr(0, lastIndex) + "...";
            } else {
                finalStr = this.valueOf().substr(0, n-3) + "...";
            }
        }

        return finalStr;
    };

    String.format = function (strToFormat) {

        for (let i = 1; i <= arguments.length - 1; i++) {
            let currentParameter = arguments[i];
            let parameterIndex = i - 1;

            for (let word of strToFormat.split(' ')) {
                if (word.includes('{') && word.includes('}')) {
                    let placeholderIndex = Number(word[1]);

                    if (placeholderIndex === parameterIndex) {
                        strToFormat = strToFormat.replace(word, currentParameter);
                    }
                }
            }
        }

        return strToFormat;
    };
})();


let testString = 'the quick brown fox jumps over the lazy';
testString = testString.truncate(10);
console.log(testString);
