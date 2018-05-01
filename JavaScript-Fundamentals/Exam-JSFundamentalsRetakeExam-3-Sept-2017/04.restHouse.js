function accomodateGuests(rooms, guests) {
    for (var i = 0; i < rooms.length; i++) {
        let currentRoom = rooms[i];
    }
}

accomodateGuests([ { number: '206', type: 'double-bedded' },
        { number: '311', type: 'triple' } ],
    [ { first: { name: 'Tanya Popova', gender: 'female', age: 24 },
        second: { name: 'Miglena Yovcheva', gender: 'female', age: 23 } },
        { first: { name: 'Katerina Stefanova', gender: 'female', age: 23 },
            second: { name: 'Angel Nachev', gender: 'male', age: 22 } },
        { first: { name: 'Tatyana Germanova', gender: 'female', age: 23 },
            second: { name: 'Boryana Baeva', gender: 'female', age: 22 } } ]
);