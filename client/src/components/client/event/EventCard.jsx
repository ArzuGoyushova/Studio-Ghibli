import React from 'react'
import ViewDetails from './ViewDetails'

const EventCard = ({ event }) => {

    return (
        <div className="w-full">
            <div className='event-container my-20'>
                <div className="w-full flex flex-col rounded-lg bg-white shadow-[0_2px_15px_-3px_rgba(0,0,0,0.07),0_10px_20px_-2px_rgba(0,0,0,0.04)] dark:bg-neutral-700  md:flex-row">
                    <div className="event-card-mapouter md:w-1/3">
                        <div className="event-card-gmap-canvas h-full">
                            <iframe className="w-full h-full" id="gmap_canvas" src={`https://maps.google.com/maps?q=${event.location}&t=&z=10&ie=UTF8&iwloc=&output=embed`} frameBorder="0" scrolling="no" marginHeight="0" marginWidth="0"></iframe>
                        </div>
                    </div>

                    <div className="flex flex-col items-center justify-center p-3 w-full md:w-1/3 md:pe-4">
                        <h2
                            className="mb-3 mx-1 text-2xl md:text-3xl">
                            {event.title}
                        </h2>
                        <p className="mb-4 mx-2 text-base text-neutral-600 dark:text-neutral-200 text-s md:text-m lg:text-lg">
                            {event.description}
                        </p>
                        <p className="text-m mx-2 text-neutral-500 dark:text-neutral-300">
                            Event time: <span className='text-red-800'>{new Date(event.eventDate).toLocaleString('en-US', {
                                day: '2-digit',
                                month: '2-digit',
                                year: 'numeric',
                                hour: '2-digit',
                                minute: '2-digit',
                                hour12: false
                            })} </span>
                        </p>

                        <ViewDetails event={event}/>
                    </div>
                    <div className="event-card-picture w-full mt-2 md:w-1/3 md:mt-0">
                        <img src={`images/event/${event.imageUrl}`} className="w-full h-full" />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default EventCard
