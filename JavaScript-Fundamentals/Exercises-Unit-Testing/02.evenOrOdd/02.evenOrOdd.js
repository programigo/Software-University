function isOddOrEven(string) {
    if (typeof(string) !== 'string') {
        return undefined;
    }
    if (string.length % 2 === 0) {
        return "even";
    }

    return "odd";
}

let expect = require('chai').expect;

describe("Test isOddOrEven(string)", function () {
    describe("General functionality", function () {
        it('should be a function', function () {
            expect(typeof isOddOrEven).to.equal('function');
        });

        it('should return "undefined" if value is number', function () {
            expect(isOddOrEven(3)).to.be.undefined;
        });

        it('should return "undefined" if value is object', function () {
            expect(isOddOrEven({name: "Pesho", age: 23})).to.be.undefined;
        });

        it('should return "even" if length % 2 equals 0', function () {
            expect(isOddOrEven("pepi")).to.equal("even");
        });

        it('should return "odd" if length % 2 is different of 0', function () {
            expect(isOddOrEven("gosho")).to.equal("odd");
        });
    })
});