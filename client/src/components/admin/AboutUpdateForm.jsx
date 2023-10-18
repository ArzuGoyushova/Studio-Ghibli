import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function AboutUpdateForm() {
    const [aboutData, setAboutData] = useState("");
    const [originTitle, setOriginTitle] = useState("");
    const [originDesc, setOriginDesc] = useState("");
    const [originImage, setOriginImage] = useState([]);
    const [ghibliTitle, setGhibliTitle] = useState("");
    const [ghibliDesc, setGhibliDesc] = useState("");
    const [ghibliImage, setGhibliImage] = useState([]);
    const [globalTitle, setGlobalTitle] = useState("");
    const [globalDesc, setGlobalDesc] = useState("");
    const [globalImage, setGlobalImage] = useState([]);
    const [messageTitle, setMessageTitle] = useState("");
    const [messageDesc, setMessageDesc] = useState("");
    const [messageImage, setMessageImage] = useState([]);
    const [heightTitle, setHeightTitle] = useState("");
    const [heightDesc, setHeightDesc] = useState("");
    const [heightImage, setHeightImage] = useState([]);
    const [futureTitle, setFutureTitle] = useState("");
    const [futureDesc, setFutureDesc] = useState("");
    const [futureImage, setFutureImage] = useState([]);

    useEffect(() => {
        fetchAboutData();
    }, []);

    const fetchAboutData = async () => {
        try {
            const response = await axios.get(`
https://arzugoyushova-001-site1.htempurl.com/api/about`);
            const aboutData = response.data[0];
            console.log(aboutData);
            setAboutData(aboutData);
            setOriginTitle(aboutData.originTitle);
            setOriginDesc(aboutData.originDesc);
            setOriginImage(aboutData.originImage);
            setGhibliTitle(aboutData.ghibliTitle);
            setGhibliDesc(aboutData.ghibliDesc);
            setGhibliImage(aboutData.ghibliImage);
            setGlobalTitle(aboutData.globalTitle);
            setGlobalDesc(aboutData.globalDesc);
            setGlobalImage(aboutData.globalImage);
            setMessageTitle(aboutData.messageTitle);
            setMessageDesc(aboutData.messageDesc);
            setMessageImage(aboutData.messageImage);
            setHeightTitle(aboutData.heightTitle);
            setHeightDesc(aboutData.heightDesc);
            setHeightImage(aboutData.heightImage);
            setFutureTitle(aboutData.futurelTitle);
            setFutureDesc(aboutData.futureDesc);
            setFutureImage(aboutData.futureImage);


        } catch (error) {
            console.error("Error fetching user data:", error);
        }
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const formData = new FormData();
            formData.append("AboutId", aboutId);
            formData.append("AboutDTO.OriginTitle", originTitle);
            formData.append("AboutDTO.OriginDesc", originDesc);
            formData.append("AboutDTO.OriginImage", originImage);

            formData.append("AboutDTO.GhibliTitle", ghibliTitle);
            formData.append("AboutDTO.GhibliDesc", ghibliDesc);
            formData.append("AboutDTO.GhibliImage", ghibliImage);

            formData.append("AboutDTO.GlobalTitle", globalTitle);
            formData.append("AboutDTO.GlobalDesc", globalDesc);
            formData.append("AboutDTO.GlobalImage", globalImage);

            formData.append("AboutDTO.MessageTitle", messageTitle);
            formData.append("AboutDTO.MessageDesc", messageDesc);
            formData.append("AboutDTO.MessageImage", messageImage);

            formData.append("AboutDTO.HeightTitle", heightTitle);
            formData.append("AboutDTO.HeightDesc", heightDesc);
            formData.append("AboutDTO.HeightImage", heightImage);

            formData.append("AboutDTO.FutureTitle", futureTitle);
            formData.append("AboutDTO.FutureDesc", futureDesc);
            formData.append("AboutDTO.FutureImage", futureImage);



            const response = await axios.put(
                `
https://arzugoyushova-001-site1.htempurl.com/api/About`,
                formData
            );


            toast.success("About Information is updated successfully!", {
                position: "top-right",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                onClose: () => {
                    setTimeout(() => {
                        window.location.reload();
                    }, 2000);
                },
            });
        } catch (error) {
            console.log(error);
            toast.error("Error adding About. Please try again.", {
                position: "top-right",
                autoClose: 2000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
            });
        }
    };

    return (
        <div className="flex-grow p-8">
            <form onSubmit={handleSubmit}>
                <div className="flex flex-col gap-4">
                    <input
                        id="originTitle"
                        type="text"
                        placeholder="Origin Title"
                        value={originTitle}
                        onChange={(e) => setOriginTitle(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />
                    <input
                        id="originDesc"
                        type="text"
                        placeholder="Origin Description"
                        value={originDesc}
                        onChange={(e) => setOriginDesc(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />
                    <div>
                    </div>
                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="originImage">
                        Origin Image
                    </label>
                    <input
                        type="file"
                        id="originImage"
                        onChange={(e) => setOriginImage(e.target.files[0])}
                        className="py-2 px-3 border rounded"
                    />
                    <input
                        id="ghibliTitle"
                        type="text"
                        placeholder="Ghibli Title"
                        value={ghibliTitle}
                        onChange={(e) => setGhibliTitle(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <input
                        id="ghibliDesc"
                        type="text"
                        placeholder="Ghibli Description"
                        value={ghibliDesc}
                        onChange={(e) => setGhibliDesc(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="ghibliImage">
                        Ghibli Image
                    </label>
                    <input
                        type="file"
                        id="ghibliImage"
                        onChange={(e) => setGhibliImage(e.target.files[0])}
                        className="py-2 px-3 border rounded"
                    />

                    <input
                        id="globalTitle"
                        type="text"
                        placeholder="Global Title"
                        value={globalTitle}
                        onChange={(e) => setGlobalTitle(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <input
                        id="globalDesc"
                        type="text"
                        placeholder="Global Description"
                        value={globalDesc}
                        onChange={(e) => setGlobalDesc(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="globalImage">
                        Global Image
                    </label>
                    <input
                        type="file"
                        id="globalImage"
                        onChange={(e) => setGlobalImage(e.target.files[0])}
                        className="py-2 px-3 border rounded"
                    />

                    <input
                        id="messageTitle"
                        type="text"
                        placeholder="Message Title"
                        value={messageTitle}
                        onChange={(e) => setMessageTitle(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <input
                        id="messageDesc"
                        type="text"
                        placeholder="Message Description"
                        value={messageDesc}
                        onChange={(e) => setMessageDesc(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="messageImage">
                        Message Image
                    </label>
                    <input
                        type="file"
                        id="messageImage"
                        onChange={(e) => setMessageImage(e.target.files[0])}
                        className="py-2 px-3 border rounded"
                    />
                    <input
                        id="heightTitle"
                        type="text"
                        placeholder="Height Title"
                        value={heightTitle}
                        onChange={(e) => setHeightTitle(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <input
                        id="heightDesc"
                        type="text"
                        placeholder="Height Description"
                        value={heightDesc}
                        onChange={(e) => setHeightDesc(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="heightImage">
                        Height Image
                    </label>
                    <input
                        type="file"
                        id="heightImage"
                        onChange={(e) => setHeightImage(e.target.files[0])}
                        className="py-2 px-3 border rounded"
                    />

                    <input
                        id="futureTitle"
                        type="text"
                        placeholder="Future Title"
                        value={futureTitle}
                        onChange={(e) => setFutureTitle(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <input
                        id="futureDesc"
                        type="text"
                        placeholder="Future Description"
                        value={futureDesc}
                        onChange={(e) => setFutureDesc(e.target.value)}
                        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        required
                    />

                    <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="futureImage">
                        Future Image
                    </label>
                    <input
                        type="file"
                        id="futureImage"
                        onChange={(e) => setFutureImage(e.target.files[0])}
                        className="py-2 px-3 border rounded"
                    />



                    <button
                        type="submit"
                        className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
                    >
                        Update
                    </button>
                </div>
                <ToastContainer />
            </form>
        </div>
    );
}

export default AboutUpdateForm;