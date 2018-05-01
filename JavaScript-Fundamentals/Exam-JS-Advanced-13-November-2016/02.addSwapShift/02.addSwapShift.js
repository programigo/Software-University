function createList() {
    let myValue = 0;
    let data = [];
    return {
        add: function (item) {
            data.push(item)
        },
        shiftLeft: function () {
            if (data.length > 1) {
                let first = data.shift();
                data.push(first);
            }
        },
        shiftRight: function () {
            if (data.length > 1) {
                let last = data.pop();
                data.unshift(last);
            }
        },
        swap: function (index1, index2) {
            if (!Number.isInteger(index1) || index1 < 0 || index1 >= data.length ||
                !Number.isInteger(index2) || index2 < 0 || index2 >= data.length ||
                index1 === index2) {
                return false;
            }
            let temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
            return true;
        },
        toString: function () {
            return data.join(", ");
        }
    };
}

let expect = require('chai').expect;

describe("All Tests", function () {
    let list;

    beforeEach(function () {
        list = createList();
    });

    it('should be a function', function () {
        expect(typeof createList).to.equal('function');
    });

    it('should have add property', function () {
        expect(list.hasOwnProperty('add')).to.be.true;
    });

    it('should have shiftLeft property', function () {
        expect(list.hasOwnProperty('shiftLeft')).to.be.true;
    });

    it('should have shiftRight property', function () {
        expect(list.hasOwnProperty('shiftRight')).to.be.true;
    });

    it('should have swap property', function () {
        expect(list.hasOwnProperty('swap')).to.be.true;
    });

    it('should have toString property', function () {
        expect(list.hasOwnProperty('toString')).to.be.true;
    });

    it('should append item at the end of the list', function () {
        list.add(7);
        list.add(3);
        list.add('Pesho');
        expect(list.toString()).to.equal('7, 3, Pesho');
    });

    it('should not shift left if array length is smaller than 1', function () {
        list.add(6);
        list.shiftLeft();
        expect(list.toString()).to.equal('6');
    });

    it('should shift left successfully', function () {
        list.add(7);
        list.add(3);
        list.add('Pesho');
        list.shiftLeft();
        expect(list.toString()).to.equal('3, Pesho, 7');
    });

    it('should not shift right if array length is smaller than 1', function () {
        list.add(6);
        list.shiftRight();
        expect(list.toString()).to.equal('6');
    });

    it('should shift right successfully', function () {
        list.add(7);
        list.add(3);
        list.add('Pesho');
        list.shiftRight();
        expect(list.toString()).to.equal('Pesho, 7, 3');
    });

    it('should not swap items if index1 is string value', function () {
        expect(list.swap('Pesho', 1)).to.be.false;
    });

    it('should not swap items if index1 is floating-point value', function () {
        expect(list.swap(1.5, 1)).to.be.false;
    });

    it('should not swap items if index1 is smaller than 0', function () {
        expect(list.swap(-6, 1)).to.be.false;
    });

    it('should not swap items if index1 is equal to array length', function () {
        list.add(6);
        expect(list.swap(1, 5)).to.be.false;
    });

    it('should not swap items if index1 is bigger than array length', function () {
        list.add(6);
        expect(list.swap(2, 1)).to.be.false;
    });

    it('should not swap items if index2 is floating-point value', function () {
        expect(list.swap(1, 1.6)).to.be.false;
    });

    it('should not swap items if index2 is smaller than 0', function () {
        expect(list.swap(6, -1)).to.be.false;
    });

    it('should not swap items if index2 is equal to array length', function () {
        list.add(6);
        expect(list.swap(0, 1)).to.be.false;
    });

    it('should not swap items if index2 is bigger than array length', function () {
        list.add(6);
        expect(list.swap(1, 2)).to.be.false;
    });

    it('should not swap items if index1 and index2 are equal', function () {
        list.add(6);
        list.add(7);
        expect(list.swap(1, 1)).to.be.false;
    });

    it('should successfully swap items if given indexes are numbers', function () {
        list.add(6);
        list.add(7);
        list.add(5);
        list.swap(0, 2);
        expect(list.toString()).to.equal('5, 7, 6');
    });

    it('should successfully print the array with toString called', function () {
        list.add(4);
        list.add('Gosho');
        list.add('8');
        expect(list.toString()).to.equal('4, Gosho, 8');
    });
});