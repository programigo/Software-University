function sum(arr) {
    let sum = 0;
    for (num of arr)
        sum += Number(num);
    return sum;
}

let expect = require('chai').expect;

describe("Test summator", function () {
    it('Should return 3 for [1,2]', function () {
        let expected = 3;
        let actual = sum([1, 2]);
        expect(actual).to.equal(expected);
    });

    it('Should return 1 for [1]', function () {
        let expected = 1;
        let actual = sum([1]);
        expect(actual).to.equal(expected);
    });

    it('Should return 0 for []', function () {
        let expected = 0;
        let actual = sum([]);
        expect(actual).to.equal(expected);
    });

    it('Should return 3 for [1.5, 2.5, -1]', function () {
        let expected = 3;
        let actual = sum([1.5, 2.5, -1]);
        expect(actual).to.equal(expected);
    });

    it('Should return NaN for "invalid data"', function () {
        let actual = sum(["invalid data"]);
        expect(actual).to.be.NaN;
    });
});