
function openWindow(url) {
    window.open(url, '_blank', 'width=800,height=600,resizable=yes,scrollbars=yes');
}
function dialogShow(dialogId) {
    const dialog = document.getElementById(dialogId);
    if (dialog) {
        dialog.showModal(); // Dialog'u modal olarak açar
    }
}

function dialogClose(dialogId) {
    const dialog = document.getElementById(dialogId);
    if (dialog) {
        dialog.close(); // Dialog'u kapatýr
    }
}
function openPdfBlob(base64Data) {
    const blob = new Blob([base64Data], { type: 'application/pdf' });
    const url = URL.createObjectURL(blob);
    window.open(url, '_blank');
}