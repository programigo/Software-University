function attachEvents() {
    let cities = [];

    $('#btnLoadTowns').on('click', async function () {
        let towns = $('#towns').val().split(', ');
        for (let town of towns) {
            cities.push({name: town});
        }
        let source = await $.get('towns-template.hbs');
        let template = Handlebars.compile(source);
        let context = {
            cities
        };
        let html = template(context);
        $('#root').html(html);
    });
}