import React, { useEffect, useState } from 'react'
import {
  Banner,
  BoxContent,
  Footer,
  Header,
  PaginationCustom,
} from '../../components'
import srcURL from '../../srcURL.json'
import { Grid } from 'semantic-ui-react'
import { useDispatch, useSelector } from 'react-redux'
import { getBlogsAPIWithPagination } from '../../redux/features/PostSlice'
import { VerticalBox } from '../../components/BoxItem'

import './blogStyles.scss'
import { setActiveMenuModal } from '../../redux/features/GeneralSlice'
import { menu } from '../../config/MenuName'
import { screenType } from '../../config/ScreenType'
import { convertDate } from '../../config/Function'

const Blogs = () => {
  const titleImage = [
    srcURL.blogsTitleImage1,
    srcURL.blogsTitleImage2,
    srcURL.blogsTitleImage3,
    srcURL.blogsTitleImage4,
    srcURL.blogsTitleImage5,
  ]

  const minNumber = 1

  const [activePage, setActivePage] = useState(minNumber)

  const columnNumber = {
    oneCol: 1,
    twoCol: 2,
    threeCol: 3,
  }

  const { data, pageSize, totalPages, status } = useSelector(
    (state) => state.post.blogsWithPagination,
  )
  const dispatch = useDispatch()

  const { currentWidth } = useSelector((state) => state.general)

  //Set the number of columns to display for each screen (Responsive)
  const setColumn = () => {
    if (currentWidth <= screenType.mobileL) {
      return columnNumber.oneCol
    } else if (currentWidth <= screenType.tablet) {
      return columnNumber.twoCol
    }
    return columnNumber.threeCol
  }

  // Highlight blogs text on MenuModal
  useEffect(() => {
    dispatch(setActiveMenuModal(menu.blogs))
  }, []) // eslint-disable-line react-hooks/exhaustive-deps

  useEffect(() => {
    let query = {
      PageNumber:
        activePage < minNumber || activePage > totalPages
          ? minNumber
          : activePage,
      PageSize: pageSize < minNumber ? minNumber : pageSize,
    }
    dispatch(getBlogsAPIWithPagination(query))
  }, [activePage]) // eslint-disable-line react-hooks/exhaustive-deps

  // Make a scroll the screen when starting
  useEffect(() => {
    const scrollSreen = setTimeout(() => {
      window.scrollTo(0, window.innerHeight)
    }, 500)
    return () => clearTimeout(scrollSreen)
  }, [activePage])

  /**
   * Catch event when activePage was changed
   *
   * @param {Object} e The event object.
   * @param {Number} activePage The activePage from handle event.
   */
  const handlePageChange = (e, { activePage }) => {
    setActivePage(activePage)
  }

  return (
    <div className="blogs-page">
      <Header />
      <Banner title={titleImage} bgImage={srcURL.blogsBackgroundImage} />
      <BoxContent>
        <Grid columns={setColumn()} className="center">
          <Grid.Row>
            {status.success &&
              data.map((item, index) => (
                <Grid.Column key={index}>
                  <VerticalBox
                    image={item.image}
                    author={item.author}
                    header={item.title}
                    description={item.shortDescription}
                    link={item.url}
                    postdate={convertDate(item.createdTime)}
                  />
                </Grid.Column>
              ))}
          </Grid.Row>
        </Grid>
        <PaginationCustom
          activePage={activePage}
          totalPages={totalPages}
          onPageChange={handlePageChange}
        />
      </BoxContent>
      <Footer isBlogsPage={true} footerLocationStyle={{ marginTop: 100 }} />
    </div>
  )
}

export default Blogs
