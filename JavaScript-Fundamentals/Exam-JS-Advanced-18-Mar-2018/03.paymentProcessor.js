class PaymentProcessor {
    constructor(){
        this.payments = [];
        this.options = {
            types: ["service", "product", "other"],
            precision: 2
        }
    }

    registerPayment(id, name, type, value) {
        if (id === '' || name === '' ||  isNaN(value) || !this.options.types.includes(type)
                || this.payments.find(p => p.ID === id)) {
            throw new Error();
        }
        this.payments.push({ID: id, Name: name, Type: type, Value: value});
    }

    deletePayment(id) {
        if (!this.payments.find(p => p.ID === id)) {
            throw new Error('ID not found');
        }
        let payment = this.payments.find(p => p.ID === id);
        let index = this.payments.indexOf(payment);
        if (index > -1) {
            this.payments.splice(index, 1);
        }
    }

    get(id) {
        if (!this.payments.find(p => p.ID === id)) {
            throw new Error('ID not found');
        }
        let payment = this.payments.find(p => p.ID === id);
        let result = `Details about payment ID: ${payment.ID}\n- Name: ${payment.Name}\n- Type: ${payment.Type}\n- Value: ${payment.Value.toFixed(this.options.precision)}`;

        return result;
    }

    setOptions(options) {
        let optionsStru = Object.keys(options);
        for (let option of optionsStru) {
            this.options[option] = options[option];
        }
    }

    toString() {
        if (this.payments.length > 0) {
            let sum = 0;
            this.payments.forEach(p => sum += p.Value);
            return `Summary:\n- Payments: ${this.payments.length}\n- Balance: ${sum}`;
        } else {
            return `Summary:\n- Payments: ${this.payments.length}\n- Balance: 0`;
        }
    }
}

let generalPayments = new PaymentProcessor({types: ['material']}, {names: ['someName']});
generalPayments.registerPayment('0001', 'Microchips', 'material', 15000);
generalPayments.registerPayment('01A3', 'Biopolymer', 'material', 23000);