function listBuilder(selector) {
    return {
        createNewList: function() {
            $(selector).empty();
            $(selector).append('<ul>');
        },
        addItem: function(text) {
            let li = $('<li>').text(text);
            let upButton = $('<button>Up</button>').on('click', () => {
                li.insertBefore(li.prev());
            });
            let downButton = $('<button>Down</button>').on('click', () => {
                li.insertAfter(li.next());
            });
            li.append(upButton);
            li.append(downButton);
            $(selector + " ul").append(li);
        }
    }
}