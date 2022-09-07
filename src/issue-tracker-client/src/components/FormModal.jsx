import React from 'react'

export default function FormModal({id, form, title}) {
    return (
       <>
        <input type="checkbox" id={id} className="modal-toggle" />
					<div className="modal">
						<div className="modal-box relative">
							<label htmlFor={id} className="btn btn-sm btn-circle absolute right-2 top-2">
								✕
							</label>
							<h3 className="text-lg font-bold">{title}</h3>
							{form}
						</div>
					</div>
       </>
    )
}
