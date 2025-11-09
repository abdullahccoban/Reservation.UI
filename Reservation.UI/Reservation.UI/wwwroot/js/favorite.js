async function addFavorite(id) {
    const payload = {
        hotelId: id
    }

    const res = await fetch("/favorite/add", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
    });

    if (res.ok) location.reload();
}

async function removeFavorite(id) {
    const payload = {
        hotelId: id
    }

    const res = await fetch("/favorite/remove", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(payload)
    });

    if (res.ok) location.reload();
}