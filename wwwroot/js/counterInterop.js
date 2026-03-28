export function preventContextMenu(elementId)
{
    document.getElementById(elementId).addEventListener('contextmenu', toggleBackgroundColor);
}

function toggleBackgroundColor()
{
    const el = document.getElementById("counterBody");
    if (!el) return; // avoid runtime error if element not found

    //event.preventDefault(); // actually suppresses the browser context menu

    if (el.style.backgroundColor === "lightgray")
        el.style.backgroundColor = "white";
    else
        el.style.backgroundColor = "lightgray";
}
