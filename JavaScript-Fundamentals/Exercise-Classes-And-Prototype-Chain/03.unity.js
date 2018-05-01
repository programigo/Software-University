class Rat {
    constructor(name) {
        this.name = name;
        this.unitedRats = [];
    }

    unite(otherRat) {
        if (otherRat.constructor.name === 'Rat') {
            this.unitedRats.push(otherRat);
        }
    }

    getRats() {
        return this.unitedRats;
    }

    toString() {
        if (this.unitedRats.length === 0) {
            return this.name;
        } else {
            return this.name + '\n' + `${this.unitedRats.map(r => `##${r.name}`).join('\n')}`;
        }

    }
}

let test = new Rat("Pesho");
console.log(test.toString());

console.log(test.getRats());

test.unite(new Rat("Gosho"));
test.unite(new Rat("Sasho"));
console.log(test.getRats());

console.log(test.toString());
