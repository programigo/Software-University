let entries = (() => {
    function getEntriesByReceiptId(receiptId) {
        const endpoint = `entries?query={"receiptId":"${receiptId}"}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }
    
    function createEntry(postId, content, author) {
        const endpoint = 'entries';
        let data = { postId, content, author };

        return remote.post('appdata', endpoint, 'kinvey', data);
    }

    function deleteEntry(commentId) {
        const endpoint = `entries/${commentId}`;

        return remote.remove('appdata', endpoint, 'kinvey');
    }



    return {
        getEntriesByReceiptId,
        createEntry,
        deleteEntry
    }

})();