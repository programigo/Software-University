function attachEvents() {
    const baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook';
    const personField = $('#person');
    const phoneField = $('#phone');

    $('#btnLoad').on('click', loadContacts);

    $('#btnCreate').on('click', createContact);

    function loadContacts() {
        $('#phonebook').empty();
        $.ajax({
            method: 'GET',
            url: baseUrl + '.json'
        }).then(displayContacts)
            .catch(displayError);
    }

    function displayContacts(contactsInfo) {
        for (let contact in contactsInfo) {
            let li = $(`<li>${contactsInfo[contact].person}: ${contactsInfo[contact].phone}</li>`)
                .append($('<button>[Delete]</button>').on('click', function () {
                    $.ajax({
                        method: 'DELETE',
                        url: `${baseUrl}/${contact}.json`
                    }).then(() => $(li).remove())
                        .catch(displayError)
                }));

            $('#phonebook').append(li);
        }
    }

    function displayError(err) {
        $("#phonebook").append($("<li>Error</li>"));
    }


    function createContact() {
        let name = personField.val();
        let phone = phoneField.val();
        let contactAsJSON = JSON.stringify({person: name, phone: phone});
        $.ajax({
            method: 'POST',
            url: baseUrl + '.json',
            data: contactAsJSON
        }).then(loadContacts)
            .catch(displayError);

        personField.val('');
        phoneField.val('');
    }
}