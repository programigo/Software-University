const createCalculator = require('../07.addSubtract').createCalculator;
let expect = require('chai').expect;

describe("Calculator maker", function () {
    let calc;

    beforeEach(function () {
        calc = createCalculator();
    });

    it('should return an object', function () {
        expect(typeof calc).to.equal('object');
    });

    it('should have 0 value when created', function () {
        expect(calc.get()).to.equal(0);
    });

    it('should return value = 5 when add(2) and add(3) functions are called', function () {
        calc.add(2);
        calc.add(3);
        expect(calc.get()).to.equal(5);
    });

    it('should return value = -5 when subtract(2) and subtract(3) functions are called', function () {
        calc.subtract(2);
        calc.subtract(3);
        expect(calc.get()).to.equal(-5);
    });

    it('should return value = 4.2 when add(5.3) and subtract(1.1) functions are called', function () {
        calc.add(5.3);
        calc.subtract(1.1);
        expect(calc.get()).to.be.closeTo(4.2, 0.001);
    });

    it('should return correct value when called with string numbers', function () {
        calc.add(10);
        calc.subtract('7');
        calc.add('-2');
        calc.subtract(-1);
        expect(calc.get()).to.be.equal(2);
    });

    it('should return NaN when add() is called with text string', function () {
        calc.add('hello');
        expect(calc.get()).to.be.NaN;
    });

    it('should return NaN when subtract() is called with text string', function () {
        calc.subtract('hello');
        expect(calc.get()).to.be.NaN;
    });
});