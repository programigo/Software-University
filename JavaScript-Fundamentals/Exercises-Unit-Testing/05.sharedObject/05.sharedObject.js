let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require('jquery');

document.body.innerHTML = `<body>
    <div id="wrapper">
        <input type="text" id="name">
        <input type="text" id="income">
    </div>
</body>
`;

let sharedObject = {
    name: null,
    income: null,
    changeName: function (name) {
        if (name.length === 0) {
            return;
        }
        this.name = name;
        let newName = $('#name');
        newName.val(this.name);
    },
    changeIncome: function (income) {
        if (!Number.isInteger(income) || income <= 0) {
            return;
        }
        this.income = income;
        let newIncome = $('#income');
        newIncome.val(this.income);
    },
    updateName: function () {
        let newName = $('#name').val();
        if (newName.length === 0) {
            return;
        }
        this.name = newName;
    },
    updateIncome: function () {
        let newIncome = $('#income').val();
        if (isNaN(newIncome) || !Number.isInteger(Number(newIncome)) || Number(newIncome) <= 0) {
            return;
        }
        this.income = Number(newIncome);
    }
};

describe("Test sharedObject functionality", function () {
    describe("Testing null values of properties", function () {
        it('name should be null by default', function () {
            expect(sharedObject.name).to.be.null;
        });

        it('income should be null by default', function () {
            expect(sharedObject.income).to.be.null;
        });
    });

    describe("changeName(name)", function () {
        it('should not make changes if passed parameter is an empty string', function () {
            sharedObject.changeName('');
            expect(sharedObject.name).to.be.null;
        });

        it('should change name to passed value', function () {
            sharedObject.changeName('Pesho');
            expect(sharedObject.name).to.equal('Pesho');
        });
        
        describe("name input tests", function () {
            it('with empty string name should be null', function () {
                sharedObject.changeName('Nakov');
                sharedObject.changeName('');
                let nameText = $('#name');
                expect(nameText.val()).to.equal('Nakov');
            });

            it('with a non-empty string name should not be null', function () {
                sharedObject.changeName('Pesho');
                let nameText = $('#name');
                expect(nameText.val()).to.equal('Pesho');
            });
        });
    });

    describe("changeIncome(income)", function () {
        it('should not change the value if given parameter is not a number', function () {
            sharedObject.changeIncome('gogo');
            expect(sharedObject.income).to.be.null;
        });

        it('should not change the value if given parameter is floating-point number', function () {
            sharedObject.changeIncome(54);
            sharedObject.changeIncome(4.87);
            expect(sharedObject.income).to.be.equal(54);
        });

        it('should not change the value if given parameter < 0', function () {
            sharedObject.changeIncome(54);
            sharedObject.changeIncome(-4);
            expect(sharedObject.income).to.be.equal(54);
        });

        it('should not change the value if given parameter = 0', function () {
            sharedObject.changeIncome(54);
            sharedObject.changeIncome(0);
            expect(sharedObject.income).to.be.equal(54);
        });

        it('should change income with value added', function () {
            sharedObject.changeIncome(10);
            expect(sharedObject.income).to.be.equal(10);
        });

        describe("income input tests", function () {
            it('should not change the input if given parameter is not a number', function () {
                sharedObject.changeIncome(32);
                sharedObject.changeIncome('gogo');
                let incomeField = $('#income');
                expect(Number(incomeField.val())).to.equal(32);
            });

            it('with negative input income should be null', function () {
                sharedObject.changeIncome(20);
                sharedObject.changeIncome(-5);
                let incomeField = $('#income');
                expect(Number(incomeField.val())).to.equal(20);
            });

            it('should not change the value if given parameter is floating-point number', function () {
                sharedObject.changeIncome(54);
                sharedObject.changeIncome(4.87);
                let incomeField = $('#income');
                expect(Number(incomeField.val())).to.equal(54);
            });

            it('should not change the value if given parameter < 0', function () {
                sharedObject.changeIncome(54);
                sharedObject.changeIncome(-4);
                let incomeField = $('#income');
                expect(Number(incomeField.val())).to.equal(54);
            });

            it('should not change the value if given parameter = 0', function () {
                sharedObject.changeIncome(54);
                sharedObject.changeIncome(0);
                let incomeField = $('#income');
                expect(Number(incomeField.val())).to.equal(54);
            });

            it('with a non-negative input income should not be null', function () {
                sharedObject.changeIncome(40);
                let incomeField = $('#income');
                expect(Number(incomeField.val())).to.equal(40);
            });
        });
    });

    describe("updateName test", function () {
        it('when name textbox value is an empty string - no changes should be made to name property', function () {
            $('#name').val('');
            sharedObject.name = 'Pepi';
            sharedObject.updateName();
            expect(sharedObject.name).to.equal('Pepi');
        });

        it('when name textbox value is string it should change the name property', function () {
            $('#name').val('Viktor');
            sharedObject.name = 'Pepi';
            sharedObject.updateName();
            expect(sharedObject.name).to.equal('Viktor');
        });
    });

    describe("updateIncome test", function () {
        it('should not change income property when textbox is string value', function () {
            $('#income').val('Viktor');
            sharedObject.income = 10;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.equal(10);
        });

        it('should not change income property when textbox is floating-point value', function () {
            $('#income').val(1.5);
            sharedObject.income = 20;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.equal(20);
        });

        it('should not change income property when textbox is < 0', function () {
            $('#income').val(-7);
            sharedObject.income = 20;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.equal(20);
        });

        it('should not change income property when textbox = 0', function () {
            $('#income').val(0);
            sharedObject.income = 20;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.equal(20);
        });

        it('should change income property when is positive number', function () {
            $('#income').val(60);
            sharedObject.income = 20;
            sharedObject.updateIncome();
            expect(sharedObject.income).to.equal(60);
        });
    })
});