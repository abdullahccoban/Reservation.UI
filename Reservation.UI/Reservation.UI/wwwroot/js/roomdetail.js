const errorFeatureMsg = document.getElementById("errorFeatureMsg");
const roomFeature = document.getElementById("roomFeature");
const roomFeatureId = document.getElementById('roomFeatureId');
const roomFeatureRoomId = document.getElementById('roomFeatureRoomId');

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-feature-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn_feature");
    errorFeatureMsg.classList.add('hidden');

    if (isEdit) {
        roomFeature.value = target.dataset.feature;
        roomFeatureId.value = target.dataset.id;
        roomFeatureRoomId.value = target.dataset.roomId;
    } else {
        roomFeature.value = "";
        roomFeatureId.value = "";
        roomFeatureRoomId.value = target.dataset.roomId;
    }
})

const saveFeatureButton = document.getElementById('saveFeatureButton');

saveFeatureButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (roomFeatureId.value !== '') {
        updateRoomFeature(roomFeatureId.value, roomFeatureRoomId.value, roomFeature.value);
    } else {
        createRoomFeature(roomFeatureRoomId.value, roomFeature.value);
    }
})

async function createRoomFeature(roomId, feature) {
    let formData = {
        roomId: roomId,
        feature: feature
    };

    let response = await fetch("/roomFeature/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorFeatureMsg.classList.remove('hidden');
    }
}

async function updateRoomFeature(id, roomId, feature) {
    let formData = {
        id: id,
        roomId: roomId,
        feature: feature
    };

    let response = await fetch("/roomFeature/update", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorFeatureMsg.classList.remove('hidden');
    }
}

async function removeRoomFeature(id) {
    let response = await fetch(`/roomFeature/remove?id=${id}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.ok) {
        location.reload();
    } else {
        errorFeatureMsg.classList.remove('hidden');
    }
}

const errorPriceMsg = document.getElementById("errorPriceMsg");
const roomPrice = document.getElementById("roomPrice");
const roomPriceId = document.getElementById('roomPriceId');
const roomPriceRoomId = document.getElementById('roomPriceRoomId');
const roomPriceStartDate = document.getElementById("roomPriceStartDate");
const roomPriceEndDate = document.getElementById("roomPriceEndDate");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-price-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn_price");
    errorPriceMsg.classList.add('hidden');

    if (isEdit) {
        roomPrice.value = target.dataset.price;
        roomPriceId.value = target.dataset.id;
        roomPriceRoomId.value = target.dataset.roomId;
        roomPriceStartDate.value = formatDateForDisplay(target.dataset.startDate);
        roomPriceEndDate.value = formatDateForDisplay(target.dataset.endDate);
    } else {
        roomPrice.value = "";
        roomPriceId.value = "";
        roomPriceStartDate.value = "";
        roomPriceEndDate.value = "";
        roomPriceRoomId.value = target.dataset.roomId;
    }
})

const savePriceButton = document.getElementById('savePriceButton');

savePriceButton.addEventListener('click', (e) => {
    e.preventDefault();
    debugger;
    if (roomPriceId.value !== '') {
        updateRoomPrice(roomPriceId.value, roomPriceRoomId.value, roomPrice.value, roomPriceStartDate.value, roomPriceEndDate.value, roomPriceRoomId.value);
    } else {
        createRoomPrice(roomPriceRoomId.value, roomPrice.value, roomPriceStartDate.value, roomPriceEndDate.value);
    }
})

async function createRoomPrice(roomId, price, startDate, endDate) {
    let formData = {
        roomId: roomId,
        price: price,
        startDate: parseDateToUTC(startDate, "MM/dd/yyyy"),
        endDate: parseDateToUTC(endDate, "MM/dd/yyyy")
    };

    let response = await fetch("/roomPrice/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorPriceMsg.classList.remove('hidden');
    }
}

async function updateRoomPrice(id, roomId, price, startDate, endDate) {
    let formData = {
        id: id,
        roomId: roomId,
        price: price,
        startDate: parseDateToUTC(startDate, "MM/dd/yyyy"),
        endDate: parseDateToUTC(endDate, "MM/dd/yyyy")
    };

    let response = await fetch("/roomPrice/update", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorPriceMsg.classList.remove('hidden');
    }
}

async function removeRoomPrice(id) {
    let response = await fetch(`/roomPrice/remove?id=${id}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.ok) {
        location.reload();
    } else {
        errorPriceMsg.classList.remove('hidden');
    }
}

function formatDateForDisplay(dateStr) {
    if (!dateStr) return "";
    const [datePart, timePart] = dateStr.split(" ");
    if (!datePart) return "";

    const [day, month, year] = datePart.split(".");
    if (!day || !month || !year) return "";
    return `${month}/${day}/${year}`;
}

function parseDateToUTC(dateStr, format = "dd/MM/yyyy") {
    if (!dateStr) return null;

    let day, month, year;

    if (format === "dd/MM/yyyy") {
        [day, month, year] = dateStr.split("/").map(Number);
    } else if (format === "MM/dd/yyyy") {
        [month, day, year] = dateStr.split("/").map(Number);
    }

    return new Date(Date.UTC(year, month - 1, day)).toISOString();
}