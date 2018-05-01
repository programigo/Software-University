class TitleBar {
    constructor(title) {
        this.title = title;
        this.links = [];
    }

    createElement() {
        let links = '';
        for (let link of this.links) {
            links += `<a class="menu-link" href="${link[0]}">${link[1]}</a>`;
        }

        let header = $('<header class="header">');
        let headerRow = $('<div class="header-row">');
        let button = $('<a class="button">&#9776;</a>').on('click', () => drawer.toggle());
        let title = $(`<span class="title">${this.title}</span>`);
        let drawer = $('<div class="drawer">');
        let menu = $(`<nav class="menu">${links}</nav>`);
        headerRow.append(button);
        headerRow.append(title);
        drawer.append(menu);
        header.append(headerRow);
        header.append(drawer);

        return header;
    }

    addLink(href, name) {
        this.links.push([href, name]);
    }

    appendTo(selector) {
        $(selector).append(this.createElement());
    }
}

let header = new TitleBar('Title Bar Problem');
header.addLink('/', 'Home');
header.addLink('about', 'About');
header.addLink('results', 'Results');
header.addLink('faq', 'FAQ');
header.appendTo('#container');