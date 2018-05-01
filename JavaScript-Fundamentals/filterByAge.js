function filterByAge(minAge, firstPersonName, firstPersonAge, secondPersonName, secondPersonAge) {
    let personOne = {name: firstPersonName, age: firstPersonAge};
    let personTwo = {name: secondPersonName, age: secondPersonAge};

    if (personOne.age >= minAge){
        console.log(personOne);
    }

    if (personTwo.age >= minAge){
        console.log(personTwo);
    }
}

filterByAge(12, 'Ivan', 15, 'Asen', 9);