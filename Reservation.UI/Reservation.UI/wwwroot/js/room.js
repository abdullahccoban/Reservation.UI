const roomType = document.getElementById('roomType');
const capacity = document.getElementById('capacity');
const count = document.getElementById('count');
const id = document.getElementById('hotelInfoId');
const hotelId = document.getElementById('hotelInfoHotelId');
const errorMsg = document.getElementById("errorMsg");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn");
    errorMsg.classList.add('hidden');

    if (isEdit) {
        roomType.value = target.dataset.desc;
        capacity.value = target.dataset.capacity;
        count.value = target.dataset.count;
        id.value = target.dataset.id;
        hotelId.value = target.dataset.hotelId;
    } else {
        roomType.value = "";
        id.value = "";
        capacity.value = "";
        count.value = "";
        hotelId.value = target.dataset.hotelId;
    }
})

const saveButton = document.getElementById('saveButton');

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (id.value !== '') {
        updateRoom(id.value, hotelId.value, roomType.value, capacity.value, count.value);
    } else {
        createRoom(hotelId.value, roomType.value, capacity.value, count.value);
    }
})

async function createRoom(hotelId, roomType, capacity, count) {
    let formData = {
        hotelId: hotelId,
        roomType: roomType,
        capacity: capacity,
        count: count
    };

    let response = await fetch("/room/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorMsg.classList.remove('hidden');
    }
}

async function updateRoom(id, hotelId, roomType, capacity, count) {
    let formData = {
        id: id,
        hotelId: hotelId,
        roomType: roomType,
        capacity: capacity,
        count: count
    };

    let response = await fetch("/room/update", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorMsg.classList.remove('hidden');
    }
}

async function removeRoom(id) {
    let response = await fetch(`/room/remove?id=${id}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.ok) {
        location.reload();
    } else {
        errorMsg.classList.remove('hidden');
    }
}