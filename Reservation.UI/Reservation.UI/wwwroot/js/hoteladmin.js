const userEmail = document.getElementById('userEmail');
const id = document.getElementById('hotelInfoId');
const hotelId = document.getElementById('hotelInfoHotelId');
const errorMsg = document.getElementById("errorMsg");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn");
    errorMsg.classList.add('hidden');
    
    if (isEdit) {
        userEmail.value = target.dataset.userEmail;
        id.value = target.dataset.id;
        hotelId.value = target.dataset.hotelId;
    } else {
        userEmail.value = "";
        id.value = "";
        hotelId.value = target.dataset.hotelId;
    }
})

const saveButton = document.getElementById('saveButton');

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (id.value !== '') {
        updateHotelAdmin(id.value, hotelId.value, userEmail.value);
    } else {
        createHotelAdmin(hotelId.value, userEmail.value);
    }
})

async function createHotelAdmin(hotelId, userEmail) {
    let formData = {
        hotelId: hotelId,
        userEmail: userEmail
    };
    
    let response = await fetch("/hotelAdmin/create", {
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

async function updateHotelAdmin(id, hotelId, userEmail) {
    let formData = {
        id: id,
        hotelId: hotelId,
        userEmail: userEmail
    };

    let response = await fetch("/hotelAdmin/update", {
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

async function removeHotelAdmin(id) {
    let response = await fetch(`/hotelAdmin/remove?id=${id}`, {
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