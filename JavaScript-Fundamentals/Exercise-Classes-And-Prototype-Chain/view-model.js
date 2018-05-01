class Textbox {
    constructor(selector, regex) {
        this._elements = $(selector);
        this._value = $(this._elements[0]).val();
        this._invalidSymbols = regex;
        this.onInput();
    }

    onInput() {
        let that = this;
        this.elements.on('input', function (event) {
            let text = $(this).val();
            that.value = text;
        });
    }

    get elements() {
        return this._elements;
    }

    get value() {
        return this._value;
    }

    set value(value) {
        this._value = value;
        for (let el of this.elements) {
            $(el).val(value);
        }
    }

    isValid() {
        return !this._invalidSymbols.test(this.value);
    }
}