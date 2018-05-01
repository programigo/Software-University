class PaymentPackage {
    constructor(name, value) {
        this.name = name;
        this.value = value;
        this.VAT = 20;      // Default value
        this.active = true; // Default value
    }

    get name() {
        return this._name;
    }

    set name(newValue) {
        if (typeof newValue !== 'string') {
            throw new Error('Name must be a non-empty string');
        }
        if (newValue.length === 0) {
            throw new Error('Name must be a non-empty string');
        }
        this._name = newValue;
    }

    get value() {
        return this._value;
    }

    set value(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('Value must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('Value must be a non-negative number');
        }
        this._value = newValue;
    }

    get VAT() {
        return this._VAT;
    }

    set VAT(newValue) {
        if (typeof newValue !== 'number') {
            throw new Error('VAT must be a non-negative number');
        }
        if (newValue < 0) {
            throw new Error('VAT must be a non-negative number');
        }
        this._VAT = newValue;
    }

    get active() {
        return this._active;
    }

    set active(newValue) {
        if (typeof newValue !== 'boolean') {
            throw new Error('Active status must be a boolean');
        }
        this._active = newValue;
    }

    toString() {
        const output = [
            `Package: ${this.name}` + (this.active === false ? ' (inactive)' : ''),
            `- Value (excl. VAT): ${this.value}`,
            `- Value (VAT ${this.VAT}%): ${this.value * (1 + this.VAT / 100)}`
        ];
        return output.join('\n');
    }
}

let expect = require('chai').expect;

describe("PaymentPackage tests", function () {

    beforeEach(function () {
        let pack;
    });

    describe("General and constructor tests", function () {
        it('should exist', function () {
            expect(typeof PaymentPackage).to.equal('function');
        });
        it('can be instantiated with two parameters - name and value', function () {
            let pack = new PaymentPackage('Transfer Fee', 1400);
            expect(typeof pack).to.equal('object');
        });
    });
    describe("name tests", function () {
        it('name set should throw exception if given parameter is not string', function () {
            expect(() => {pack = new PaymentPackage(4, 1000)}).to.throw(Error);
        });
        it('name set should throw exception if the given parameter length is 0', function () {
            let pack;
            expect(() => {pack = new PaymentPackage('', 1000)}).to.throw(Error);
        });
        it('should successfully create an instance with valid name', function () {
            expect(typeof (pack = new PaymentPackage('Transfer Fee', 1000))).to.equal('object');
        });
        it('get name should return correct value', function () {
            pack = new PaymentPackage('Mail', 54);
            expect(pack.name).to.equal('Mail');
        });
    });
    describe("value tests", function () {
        it('should throw an error if given value is not a number', function () {
            expect(() => {pack = new PaymentPackage('Neshto', 'nishto')}).to.throw(Error);
        });
        it('should throw an error if given value is smaller thn 0', function () {
            expect(() => {pack = new PaymentPackage('Neshto', -1)}).to.throw(Error);
        });
        it('should work if value is exactly 0', function () {
            expect(typeof (pack = new PaymentPackage('Neshto', 0))).to.equal('object');
        });
        it('get value should return correct value', function () {
            pack = new PaymentPackage('Mail', 54);
            expect(pack.value).to.equal(54);
        });
    });
    describe("VAT tests", function () {
        it('should be 20 by default', function () {
            pack = new PaymentPackage('Neshto', 80);
            expect(pack.VAT).to.equal(20);
        });
        it('should throw an error if given value is not a number', function () {
            pack = new PaymentPackage('Neshto', 80);
            expect(() => {pack.VAT = 'not vat'}).to.throw(Error);
        });
        it('should throw an error if given value is smaller thn 0', function () {
            pack = new PaymentPackage('Neshto', 47);
            expect(() => {pack.VAT = -6}).to.throw(Error);
        });
        it('should work if value is exactly 0', function () {
            pack = new PaymentPackage('Neshto', 0);
            expect(pack.VAT = 0).to.equal(0);
        });
        it('get value should return correct value', function () {
            pack = new PaymentPackage('Mail', 54);
            pack.VAT = 63;
            expect(pack.VAT).to.equal(63);
        });
    });
    describe("active tests", function () {
        it('should be true by defalut', function () {
            pack = new PaymentPackage('Mail', 54);
            expect(pack.active).to.be.true;
        });
        it('should throw error if given set value is not true or false (string test)', function () {
            pack = new PaymentPackage('Mail', 54);
            expect(() => {pack.active = 'not boolean'}).to.throw(Error);
        });
        it('should throw error if given set value is not true or false (number test)', function () {
            pack = new PaymentPackage('Mail', 54);
            expect(() => {pack.active = 1}).to.throw(Error);
        });
        it('should work correct with valid value', function () {
            pack = new PaymentPackage('Mail', 54);
            pack.active = false;
            expect(pack.active).to.be.false;
        });
    });
    describe("toString() tests", function () {
        it('should print the package name with (inactive) if active = false', function () {
            pack = new PaymentPackage('Mail', 54);
            pack.active = false;
            expect(pack.toString()).to.equal('Package: Mail (inactive)\n- Value (excl. VAT): 54\n- Value (VAT 20%): 64.8');
        });

        it('should print the package name without (inactive) if active = true', function () {
            pack = new PaymentPackage('Mail', 54);
            expect(pack.toString()).to.equal('Package: Mail\n- Value (excl. VAT): 54\n- Value (VAT 20%): 64.8');
        });
    })
});