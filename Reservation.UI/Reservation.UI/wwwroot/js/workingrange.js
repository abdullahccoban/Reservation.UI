const errorWorkingRangeMsg = document.getElementById("errorWorkingRangeMsg");
const year = document.getElementById("year");
const workingRangeId = document.getElementById('workingRangeId');
const workingRangeHotelId = document.getElementById('workingRangeHotelId');
const workingRangeOpeningDate = document.getElementById("workingRangeOpeningDate");
const workingRangeClosingDate = document.getElementById("workingRangeClosingDate");

document.addEventListener("click", (e) => {
    const target = e.target.closest("[data-modal-toggle='crud-modal']");
    if (!target) return;
    const isEdit = target.id.includes("editBtn");
    errorWorkingRangeMsg.classList.add('hidden');

    if (isEdit) {
        year.value = target.dataset.year;
        workingRangeId.value = target.dataset.id;
        workingRangeHotelId.value = target.dataset.hotelId;
        workingRangeOpeningDate.value = formatDateForDisplay(target.dataset.openingDate);
        workingRangeClosingDate.value = formatDateForDisplay(target.dataset.closingDate);
    } else {
        year.value = "";
        workingRangeId.value = "";
        workingRangeOpeningDate.value = "";
        workingRangeClosingDate.value = "";
        workingRangeHotelId.value = target.dataset.hotelId;
    }
})

const saveWorkingRangeButton = document.getElementById('saveWorkingRangeButton');

 saveWorkingRangeButton.addEventListener('click', (e) => {
    e.preventDefault();
    if (workingRangeId.value !== '') {
        updateWorkingRange(workingRangeId.value, workingRangeHotelId.value, year.value, workingRangeOpeningDate.value, workingRangeClosingDate.value);
    } else {
        createWorkingRange(workingRangeHotelId.value, year.value, workingRangeOpeningDate.value, workingRangeClosingDate.value);
    }
})

async function createWorkingRange(hotelId, year, openingDate, closingDate) {
    let formData = {
        hotelId: hotelId,
        year: year,
        openingDate: parseDateToUTC(openingDate, "MM/dd/yyyy"),
        closingDate: parseDateToUTC(closingDate, "MM/dd/yyyy")
    };

    let response = await fetch("/workingRange/create", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorWorkingRangeMsg.classList.remove('hidden');
    }
}

async function updateWorkingRange(id, hotelId, year, openingDate, closingDate) {
    let formData = {
        id: id,
        hotelId: hotelId,
        year: year,
        openingDate: parseDateToUTC(openingDate, "MM/dd/yyyy"),
        closingDate: parseDateToUTC(closingDate, "MM/dd/yyyy")
    };

    let response = await fetch("/workingRange/update", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    });

    if (response.ok) {
        location.reload();
    } else {
        errorWorkingRangeMsg.classList.remove('hidden');
    }
}

async function removeWorkingRange(id) {
    let response = await fetch(`/workingRange/remove?id=${id}`, {
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