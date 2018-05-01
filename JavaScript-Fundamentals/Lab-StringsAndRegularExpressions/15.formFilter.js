function generateForm(username, email, phone, text) {

    for (let sentence of text) {
            sentence = sentence.replace(/(<![a-zA-Z]+!>)/g, username);
            sentence = sentence.replace(/(<@[a-zA-Z]+@>)/g, email);
            sentence = sentence.replace(/(<\+[a-zA-Z]+\+>)/g, phone);
            console.log(sentence);
        }

}

generateForm('Pesho',
    'pesho@softuni.bg',
    '90-60-90',
    ['Hello, <!username!>!',
        'Welcome to your Personal profile.',
        'Here you can modify your profile freely.',
        'Your current username is: <!fdsfs!>. Would you like to change that? (Y/N)',
        'Your current email is: <@DasEmail@>. Would you like to change that? (Y/N)',
        'Your current phone number is: <+number+>. Would you like to change that? (Y/N)']
);