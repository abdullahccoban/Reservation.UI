const photoPath = document.getElementById('photo');
const id = document.getElementById('hotelInfoId');
const hotelId = document.getElementById('hotelInfoHotelId');
const errorMsg = document.getElementById("errorMsg");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn");
    errorMsg.classList.add('hidden');

    if (isEdit) {
        photoPath.value = target.dataset.desc;
        id.value = target.dataset.id;
        hotelId.value = target.dataset.hotelId;
    } else {
        photoPath.value = "";
        id.value = "";
        hotelId.value = target.dataset.hotelId;
    }
})

const saveButton = document.getElementById('saveButton');

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (id.value !== '') {
        updatePhoto(id.value, hotelId.value, photoPath.value);
    } else {
        createPhoto(hotelId.value, photoPath.value);
    }
})

async function createPhoto(hotelId, photoPath) {
    let formData = {
        hotelId: hotelId,
        photoPath: photoPath
    };

    let response = await fetch("/photo/create", {
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

async function updatePhoto(id, hotelId, photoPath) {
    let formData = {
        id: id,
        hotelId: hotelId,
        photoPath: photoPath
    };

    let response = await fetch("/photo/update", {
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

async function removePhoto(id) {
    let response = await fetch(`/photo/remove?id=${id}`, {
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