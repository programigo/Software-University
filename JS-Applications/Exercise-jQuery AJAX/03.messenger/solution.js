function attachEvents() {
    const baseUrl = 'https://messengerapp-14f7e.firebaseio.com/messenger/.json';

    $('#submit').on('click', submitMessage);
    $('#refresh').on('click', viewMessages);

    function submitMessage() {
        let author = $('#author').val();
        let content = $('#content').val();
        let contentToJSON = JSON.stringify({author: author, content: content, timestamp: Date.now()});

       $.ajax({
           method: 'POST',
           url: baseUrl,
           data: contentToJSON
       }).then(refresh)
    }

    function viewMessages() {
        $.ajax({
            method: 'GET',
            url: baseUrl
        }).then(loadMessages)
    }
    
    function refresh() {
        $('#messages').empty();
        $.ajax({
            method: 'GET',
            url: baseUrl
        }).then(loadMessages)
    }

    function loadMessages(messages) {
        let textArea = $('#messages');
        for (let message in messages) {
            let currentMessageInfo = messages[message];
            textArea.append(`${currentMessageInfo.author}: ${currentMessageInfo.content}\n`);
        }
    }
}