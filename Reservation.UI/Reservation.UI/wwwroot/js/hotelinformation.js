const description = document.getElementById('message');
const id = document.getElementById('hotelInfoId');
const hotelId = document.getElementById('hotelInfoHotelId');
const errorMsg = document.getElementById("errorMsg");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn");
    errorMsg.classList.add('hidden');
    
    if (isEdit) {
        description.value = target.dataset.desc;
        id.value = target.dataset.id;
        hotelId.value = target.dataset.hotelId;
    } else {
        description.value = "";
        id.value = "";
        hotelId.value = target.dataset.hotelId;
    }
})

const saveButton = document.getElementById('saveButton');

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (id.value !== '') {
        updateHotelInfo(id.value, hotelId.value, description.value);
    } else {
        createHotelInfo(hotelId.value, description.value);
    }
})

async function createHotelInfo(hotelId, description) {
    let formData = {
        hotelId: hotelId,
        description: description
    };
    
    let response = await fetch("/hotelInfo/create", {
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

async function updateHotelInfo(id, hotelId, description) {
    let formData = {
        id: id,
        hotelId: hotelId,
        description: description
    };

    let response = await fetch("/hotelInfo/update", {
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

async function removeHotelInfo(id) {
    let response = await fetch(`/hotelInfo/remove?id=${id}`, {
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