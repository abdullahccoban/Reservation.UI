const tag = document.getElementById('tag');
const id = document.getElementById('hotelInfoId');
const hotelId = document.getElementById('hotelInfoHotelId');
const errorMsg = document.getElementById("errorMsg");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn");
    errorMsg.classList.add('hidden');

    if (isEdit) {
        tag.value = target.dataset.desc;
        id.value = target.dataset.id;
        hotelId.value = target.dataset.hotelId;
    } else {
        tag.value = "";
        id.value = "";
        hotelId.value = target.dataset.hotelId;
    }
})

const saveButton = document.getElementById('saveButton');

saveButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (id.value !== '') {
        updateTag(id.value, hotelId.value, tag.value);
    } else {
        createTag(hotelId.value, tag.value);
    }
})

async function createTag(hotelId, tag) {
    let formData = {
        hotelId: hotelId,
        tag: tag
    };

    let response = await fetch("/tag/create", {
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

async function updateTag(id, hotelId, tag) {
    let formData = {
        id: id,
        hotelId: hotelId,
        tag: tag
    };

    let response = await fetch("/tag/update", {
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

async function removeTag(id) {
    let response = await fetch(`/tag/remove?id=${id}`, {
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