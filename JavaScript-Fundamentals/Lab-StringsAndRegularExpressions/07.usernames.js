function getUsers(arr) {
    let pattern = /([\w]+)@([\w+\.*\w*]+)/g;
    let allUsers = [];
    let match = pattern.exec(arr);
    let currentUserInfo = '';

    while (match != null) {
        currentUserInfo = match[1] + '.';
        let domainsInfo = match[2].split('.');

        for (let i = 0; i < domainsInfo.length; i++) {
            let currentWord = domainsInfo[i];

            currentUserInfo += currentWord[0];
        }

        allUsers.push(currentUserInfo);

        match = pattern.exec(arr);
    }

    console.log(allUsers.join(', '));
}

getUsers(['peshoo@gmail.com', 'todor_43@mail.dir.bg', 'foo@bar.com']);