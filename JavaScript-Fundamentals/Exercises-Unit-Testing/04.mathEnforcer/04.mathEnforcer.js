let mathEnforcer = {
    addFive: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num + 5;
    },
    subtractTen: function (num) {
        if (typeof(num) !== 'number') {
            return undefined;
        }
        return num - 10;
    },
    sum: function (num1, num2) {
        if (typeof(num1) !== 'number' || typeof(num2) !== 'number') {
            return undefined;
        }
        return num1 + num2;
    }
};

let expect = require('chai').expect;

describe("mathEnforcer test", function () {
    describe("addFive tests", function () {
        it('should return undefined if parameter is not a number', function () {
            expect(mathEnforcer.addFive("pesho")).to.be.undefined;
        });

        it('should return correct result when adding 5 to positive value', function () {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        });

        it('should return correct result when adding 5 to negative value', function () {
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        });

        it('should return correct result when adding 5 to floating-point value', function () {
            expect(mathEnforcer.addFive(4.7)).to.be.closeTo(9.7, 0.01);
        });
    });

    describe("subtractTen tests", function () {
        it('should return undefined if parameter is not a number', function () {
            expect(mathEnforcer.subtractTen("pesho")).to.be.undefined;
        });

        it('should return correct result when subtracting 10 from positive value', function () {
            expect(mathEnforcer.subtractTen(10)).to.equal(0);
        });

        it('should return correct result when subtracting 10 from negative value', function () {
            expect(mathEnforcer.subtractTen(-5)).to.equal(-15);
        });

        it('should return correct result when subtracting 10 from floating-point value', function () {
            expect(mathEnforcer.subtractTen(-4.66)).to.be.closeTo(-14.66, 0.01);
        });
    });

    describe("sum tests", function () {
        it('should return undefined if first parameter is not a number', function () {
            expect(mathEnforcer.sum("pesho", 2)).to.be.undefined;
        });

        it('should return undefined if second parameter is not a number', function () {
            expect(mathEnforcer.sum(2, "pesho")).to.be.undefined;
        });

        it('should return correct result when summing positive numbers', function () {
            expect(mathEnforcer.sum(10, 20)).to.equal(30);
        });

        it('should return correct result when summing negative numbers', function () {
            expect(mathEnforcer.sum(-10, -28)).to.equal(-38);
        });

        it('should return correct result when summing floating-point numbers', function () {
            expect(mathEnforcer.sum(1.456, 2.585)).to.be.closeTo(4.041, 0.01);
        });
    });
});