import React, {useEffect, useState} from "react"


function Footer(props)  {
    return(
        <footer class="footer">
        <div class="wrapper">
            <ul>
                <li>
                    <span>Copyright. VegaITSourcing All rights reserved</span>
                </li>
            </ul>
            <ul class="right">
                <li>
                    <a href="javascript:;">Terms of service</a>
                </li>
                <li>
                    <a href="javascript:;" class="last">Privacy policy</a>
                </li>
            </ul>
        </div>
    </footer>
    );
}

export default Footer