function lookupChar(string, index) {
    if (typeof(string) !== 'string' || !Number.isInteger(index)) {
        return undefined;
    }
    if (string.length <= index || index < 0) {
        return "Incorrect index";
    }

    return string.charAt(index);
}

let expect = require('chai').expect;

describe("Test lookupChar(string, index) function", function () {
    it('should be a function', function () {
        expect(typeof lookupChar).to.equal('function');
    });

    it('should return "undefined" if string parameter is not actually a string', function () {
        expect(lookupChar(3, 3)).to.be.undefined;
    });

    it('should return "undefined" if index parameter is not actually number', function () {
        expect(lookupChar("Bulgaria", "troya")).to.be.undefined;
    });

    it('should return "Incorrect index" if index value >= given string length', function () {
        expect(lookupChar("ball", 4)).to.equal("Incorrect index");
    });

    it('should return "undefined" if index parameter is floating-point number', function () {
        expect(lookupChar("Bulgaria", 3.14)).to.be.undefined;
    });

    it('should return "Incorrect index" if index value < 0', function () {
        expect(lookupChar("ball", -4)).to.equal("Incorrect index");
    });

    it('should return the character at the specified index if both parameters have correct types and values', function () {
        expect(lookupChar("SoftUni", 0)).to.equal("S");
    });

    it('should return the character at the specified index if both parameters have correct types and values', function () {
        expect(lookupChar("SoftUni", 4)).to.equal("U");
    });
});