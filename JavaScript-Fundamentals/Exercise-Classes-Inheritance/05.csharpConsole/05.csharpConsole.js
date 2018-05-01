class Console {

    static get placeholder() {
        return /{\d+}/g;
    }

    static writeLine() {
        let message = arguments[0];
        if (arguments.length === 1) {
            if (typeof (message) === 'object') {
                message = JSON.stringify(message);
                return message;
            }
            else if (typeof(message) === 'string') {
                return message;
            }
        }
        else {
            if (typeof (message) !== 'string') {
                throw new TypeError("No string format given!");
            }
            else {
                let tokens = message.match(this.placeholder).sort(function (a, b) {
                    a = Number(a.substring(1, a.length - 1));
                    b = Number(b.substring(1, b.length - 1));
                    return a - b;
                });
                if (tokens.length !== (arguments.length - 1)) {
                    throw new RangeError("Incorrect amount of parameters given!");
                }
                else {
                    for (let i = 0; i < tokens.length; i++) {
                        let number = Number(tokens[i].substring(1, tokens[i].length - 1));
                        if (number !== i) {
                            throw new RangeError("Incorrect placeholders given!");
                        }
                        else {
                            message = message.replace(tokens[i], arguments[i + 1])
                        }
                    }
                    return message;
                }
            }
        }
    }
}

let expect = require('chai').expect;

describe('Testing Console class', function () {
    it('test return string element', function () {
        let argument = 'Krasi';
        expect(Console.writeLine(argument)).to.equal('Krasi');
    });

    it('test should return JSON representation of the object', function () {
        let obj = {name: 'Gogo', age: 26};
        expect(Console.writeLine(obj)).to.equal(JSON.stringify(obj));
    });

    it('should exchange placeholders with given parameters', function () {
        expect(Console.writeLine('{0}, {1}, {2}', 8, 10, 16)).to.equal('8, 10, 16');
    });

    it('test if throws error if the first argument is not string', function () {
        let nonStringArgument = 5;
        expect(() => {
            Console.writeLine(nonStringArgument, 8)
        }).to.throw(TypeError);
    });

    it('test if throws error if the number of parameters does not correspond to the number of placeholders', function () {
        expect(() => {
            Console.writeLine('{0}', 8, 9)
        }).to.throw(RangeError);
    });

    it('test placeholder indexes', function () {
        expect(() => {
            Console.writeLine('{10}', 1, 2, 4)
        }).to.throw(RangeError);
    });
});