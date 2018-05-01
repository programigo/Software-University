function isValidEmail(email) {
    let pattern = /^[A-Za-z0-9]+@[a-z]+\.[a-z]+$/g;

    let isValid = pattern.test(email);

    if (isValid) {
        console.log('Valid');
    } else {
        console.log('Invalid');
    }
}

isValidEmail('valid@email.bg');