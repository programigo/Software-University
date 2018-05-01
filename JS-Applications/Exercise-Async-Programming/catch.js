function attachEvents() {
    const APPKEY = 'kid_Sk9DMA25z';
    const USERNAME = 'guest';
    const PASSWORD = 'guest';
    const BASE64AUTH = btoa(USERNAME + ':' + PASSWORD);
    const AUTHHEADERS = {'Authorization': 'Basic ' + BASE64AUTH};
    const BASEURL = `https://baas.kinvey.com/appdata/${APPKEY}/biggestCatches`;
    const ADDFORM = $('#addForm');

    $('.load').on('click', loadCatches);
    $('.add').on('click', addCatch);

    function addCatch() {
        let angler = ADDFORM.find('.angler').val();
        let weight = +ADDFORM.find('.weight').val();
        let species = ADDFORM.find('.species').val();
        let location = ADDFORM.find('.location').val();
        let bait = ADDFORM.find('.bait').val();
        let captureTime = +ADDFORM.find('.captureTime').val();
        let obj = {angler, weight, species, location, bait, captureTime};
        $.ajax({
            method: 'POST',
            url: BASEURL,
            headers: AUTHHEADERS,
            data: obj
        })
    }

    function loadCatches() {
        $.ajax({
            method: 'GET',
            url: BASEURL,
            headers: AUTHHEADERS
        }).then(handleSuccess)
            .catch(displayError);
    }

    function handleSuccess(entries) {
        $('#catches').empty();
        for (let entry of entries) {
            let catchDiv = $(`<div class="catch" data-id="${entry._id}">`);
            catchDiv.append($('<label>Angler</label>'));
            catchDiv.append($(`<input type="text" class="angler" value="${entry.angler}">`));
            catchDiv.append($('<label>Weight</label>'));
            catchDiv.append($(`<input type="number" class="weight" value="${entry.weight}">`));
            catchDiv.append($('<label>Species</label>'));
            catchDiv.append($(`<input type="text" class="species" value="${entry.species}">`));
            catchDiv.append($('<label>Location</label>'));
            catchDiv.append($(`<input type="text" class="location" value="${entry.location}">`));
            catchDiv.append($('<label>Bait</label>'));
            catchDiv.append($(`<input type="text" class="bait" value="${entry.bait}">`));
            catchDiv.append($('<label>Capture Time</label>'));
            catchDiv.append($(`<input type="number" class="captureTime" value="${entry.captureTime}">`));
            catchDiv.append($('<button class="update">Update</button>').on('click', updateEntry));
            catchDiv.append($('<button class="delete">Delete</button>').on('click', deleteEntry));
            $('#catches').append(catchDiv);
        }
    }

    function updateEntry() {
        let catchEl = $(this).parent();
        let data = {
            angler: catchEl.find('.angler').val(),
            weight: +catchEl.find('.weight').val(),
            species: catchEl.find('.species').val(),
            location: catchEl.find('.location').val(),
            bait: catchEl.find('.bait').val(),
            captureTime: +catchEl.find('.captureTime').val()
        };

        $.ajax({
            method: 'PUT',
            url: BASEURL + '/' + catchEl.attr('data-id'),
            headers: AUTHHEADERS,
            data: data
        }).then(loadCatches)
            .catch(displayError)
    }

    function deleteEntry() {
        let catchEl = $(this).parent();

        $.ajax({
            method: 'DELETE',
            url: BASEURL + '/' + catchEl.attr('data-id'),
            headers: AUTHHEADERS
        }).then(loadCatches)
            .catch(displayError)
    }

    function displayError(err) {

    }
}