const isSymmetric = require('../05.checkForSymmetry.js').isSymmetric;

let expect = require('chai').expect;

describe("Check symmetry", function () {
    it('Should return true for [1,2,3,3,2,1]', function () {
        let expected = true;
        let actual = isSymmetric([1,2,3,3,2,1]);
        expect(actual).to.equal(expected);
    });

    it('Should return false for [1,2,3,4,2,1]', function () {
        let expected = false;
        let actual = isSymmetric([1,2,3,4,2,1]);
        expect(actual).to.equal(expected);
    });

    it('Should return true for [-1,2,-1]', function () {
        let expected = true;
        let actual = isSymmetric([-1,2,-1]);
        expect(actual).to.equal(expected);
    });

    it('Should return false for [-1,2,1]', function () {
        let expected = false;
        let actual = isSymmetric([-1,2,1]);
        expect(actual).to.equal(expected);
    });

    it('Should return false for [1,2]', function () {
        let expected = false;
        let actual = isSymmetric([1,2]);
        expect(actual).to.equal(expected);
    });

    it('Should return true for [1]', function () {
        let expected = true;
        let actual = isSymmetric([1]);
        expect(actual).to.equal(expected);
    });

    it('Should return true for [5,\'hi\',{a:5},new Date(),{a:5},\'hi\',5]', function () {
        let expected = true;
        let actual = isSymmetric([5,'hi',{a:5},new Date(),{a:5},'hi',5] );
        expect(actual).to.equal(expected);
    });

    it('Should return false for [5,\'hi\',{a:5},new Date(),{X:5},\'hi\',5]', function () {
        let expected = false;
        let actual = isSymmetric([5,'hi',{a:5},new Date(),{X:5},'hi',5]);
        expect(actual).to.equal(expected);
    });

    it('Should return false for 1,2,2,1', function () {
        let expected = false;
        let actual = isSymmetric(1,2,2,1);
        expect(actual).to.equal(expected);
    });
});