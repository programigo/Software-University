let receipts = (() => {
    function getCurrentActiveReceipt() {
        const endpoint = `receipts?query={"_acl.creator":"${sessionStorage.getItem('userId')}","active":true}`;

        return remote.get('appdata', endpoint, 'kinvey');
    }


    return {
        getCurrentActiveReceipt
    }
})();