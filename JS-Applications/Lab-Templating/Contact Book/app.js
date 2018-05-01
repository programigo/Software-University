$(() => {
    
    async function loadFiles() {
        let source = await $.get('contactTemplate.hbs');
        let template = Handlebars.compile(source);
        let data = await $.get('data.json');
        let context = {
            contacts: data,
        };
        let html = template(context);
        $('#list').find('.content').append(html);
        attachEvents();
    }
    loadFiles();

    function attachEvents() {
        $('.contact').on('click', async function () {
            let id = $(this).attr('data-id');
            let source = await $.get('detailsTemplate.hbs');
            let template = Handlebars.compile(source);
            let data = await $.get('data.json');
            let html = template(data[id]);
            $('#details').find('.content').empty();
            $('#details').find('.content').append(html);
        })
    }
});