class SortedList {
    constructor() {
        this.list = [];
    }

    add(element) {
        this.list.push(element);
        this.sort();
    }

    remove(index) {
        this.vrfyRange(index);
        this.list.splice(index, 1);
    }

    get(index) {
        this.vrfyRange(index);
        return this.list[index];
    }

    vrfyRange(index) {
        if (this.list.length == 0) throw new Error("Collection is empty.");
        if (index < 0 || index >= this.list.length) throw new Error("Index was outside the bounds of the collection.");
    }

    sort() {
        this.list.sort((a, b) => a - b);
    }

    get size() {
        return this.list.length;
    }
}

let expect = require('chai').expect;

describe("Test SortedList class", function () {
    let sortedList;

    beforeEach(function () {
        sortedList = new SortedList();
    });

    describe("general tests", function () {
        it('should be a function', function () {
            expect(typeof SortedList === 'function').to.be.true;
        });

        it('should have add function', function () {
            expect(SortedList.prototype.hasOwnProperty('add')).to.be.true;
        });

        it('should have remove function', function () {
            expect(SortedList.prototype.hasOwnProperty('remove')).to.be.true;
        });

        it('should have get function', function () {
            expect(SortedList.prototype.hasOwnProperty('get')).to.be.true;
        });

        it('should have vrfyRange function', function () {
            expect(SortedList.prototype.hasOwnProperty('vrfyRange')).to.be.true;
        });

        it('should have sort function', function () {
            expect(SortedList.prototype.hasOwnProperty('sort')).to.be.true;
        });

        it('should have size function', function () {
            expect(SortedList.prototype.hasOwnProperty('size')).to.be.true;
        });
    });

    describe("add(element) test", function () {
        it('should add new element to the array', function () {
            sortedList.add(5);
            sortedList.add(6);
            expect(sortedList.list.length).to.equal(2);
        });

        it('should sort the array', function () {
            sortedList.add(5);
            sortedList.add(4);
            sortedList.add(10);
            expect(sortedList.list.join(', ')).to.equal('4, 5, 10');
        });
    });

    describe("remove(index) test", function () {
        it('should remove element if given index is valid', function () {
            sortedList.add(3);
            sortedList.add(6);
            sortedList.remove(1);
            expect(sortedList.list.length).to.equal(1);
        });

        it('should throw error if inner list length is 0', function () {
            expect(() => {sortedList.remove(1)}).to.throw(Error);
        });

        it('should throw error if given index is smaller than 0', function () {
            expect(() => {sortedList.remove(-1).to.equal(1)}).to.throw(Error);
        });

        it('should throw error if given index is larger than the list length', function () {
            sortedList.add(3);
            sortedList.add(6);
            expect(() => {sortedList.remove(2)}).to.throw(Error);
        });
    });

    describe("get(index) test", function () {
        it('should return the element at the given index', function () {
            sortedList.add(3);
            sortedList.add(6);
            sortedList.add(9);
            expect(sortedList.get(1)).to.equal(6);
        });

        it('should throw error if inner list length is 0', function () {
            expect(() => {sortedList.get(1)}).to.throw(Error);
        });

        it('should throw error if given index is smaller than 0', function () {
            expect(() => {sortedList.get(-1)}).to.throw(Error);
        });

        it('should throw error if given index is larger than the list length', function () {
            sortedList.add(3);
            sortedList.add(6);
            expect(() => {sortedList.get(2)}).to.throw(Error);
        });
    });
    
    describe("sort() function test", function () {
        it('should keep the elements of the collection sorted in ascending order', function () {
            sortedList.add(9);
            sortedList.add(3);
            sortedList.add(27);
            sortedList.remove(1);
            sortedList.add(2);
            sortedList.add(55);
            expect(sortedList.list.join(", ")).to.equal('2, 3, 27, 55');
        });
    });

    describe("size() property test", function () {
        it('should return the number of elements', function () {
            sortedList.add(9);
            sortedList.add(3);
            sortedList.add(27);
            sortedList.add(2);
            sortedList.add(55);
            expect(sortedList.size).to.equal(5);
        });
    });
});