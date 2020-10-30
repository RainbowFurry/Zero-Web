var qrcode = new QRCode("qrcode");

function makeCode(codeContent) {
    qrcode.makeCode(codeContent);
}

makeCode("http://DarkWolfCraft.net");

        //<div id="qrcode"></div>