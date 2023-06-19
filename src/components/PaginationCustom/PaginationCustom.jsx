import React from 'react'
import { Pagination } from 'semantic-ui-react'

import './paginationCustomStyles.scss'

const PaginationCustom = ({...props}) => {

  const {onPageChange, activePage, totalPages} = props

  return (
    <div className='pagination-wrapper'>
      <Pagination
        className='pagination-container'
        activePage={activePage}
        size='tiny'
        totalPages={totalPages}
        onPageChange={onPageChange}
        ellipsisItem={undefined}
        prevItem={activePage === 1 ? null : { content: '<< Prev' }}
        nextItem={activePage === totalPages ? null : { content: 'Next >>' }}
        firstItem={null}
        lastItem={null}
      />      
    </div>
  )
}

export default PaginationCustom