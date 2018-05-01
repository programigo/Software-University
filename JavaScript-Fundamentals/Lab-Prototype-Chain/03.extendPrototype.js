let Person = require('./01.personAndTeacher');

function extendClass(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

extendClass(Person);

let p = new Person('Gogo', 'gogo@gogo.com');
console.log(p.toSpeciesString());